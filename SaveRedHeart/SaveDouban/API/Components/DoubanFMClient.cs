#region Copyright
/*
       Author:	Ran
  Last Update:	2012-7-12 6:22
Creating Time:	2012-7-12 4:24

      Project:  DoubanFM API Code Pack
         File:	DoubanFMClient.cs
      
     Copyright (c) Chobi-Q 2012 All rights reserved.
*/
#endregion
using System.Collections.Generic;
using System.Linq;

namespace ChobiQ.DoubanFMAPICodePack
{
    /// <summary>
    /// Provides methods for sending data to and receiving data 
    /// from DoubanFM server.
    /// </summary>
    public class DoubanFMClient
    {
        private UserStatus _status;
        private PlayHistory _history;
        private Queue<Song> _playlist;


        /// <summary>
        /// Get current playing list.
        /// </summary>
        public Queue<Song> Playlist
        {
            get { return _playlist; }
        }

        /// <summary>
        /// Gets current playing song.
        /// </summary>
        public Song CurrentSong
        {
            get
            {
                //Get first song in playing queue.
                if (_playlist.Count == 0)
                    return null;
                else
                    return _playlist.First();
            }
        }

        /// <summary>
        /// Gets current playing channel.
        /// </summary>
        public Channel CurrentChannel { get; private set; }

        /// <summary>
        /// Initializes a new instance of the DoubanFMClient class.
        /// </summary>
        public DoubanFMClient()
        {
            _history = new PlayHistory();
            _playlist = new Queue<Song>();
            LoadLastChannel();
        }

        /// <summary>
        /// Signs in with user email and password and
        /// receives response from DoubanFM server.
        /// </summary>
        /// <param name="email">User email.</param>
        /// <param name="password">User password.</param>
        /// <param name="saveStatus">Indicates if this client should
        /// save user's status when sign-in succeeded.</param>
        /// <returns></returns>
        public LoginResponse Login(string email, string password,
            bool saveStatus)
        {
            //Get response via http post.
            var jResp = ConnectionManager.GetPostResponse(
                ConnectionManager.LoginUri,
                new LoginRequestForm(new LoginRequest(email, password)));

            //Create response from json.
            LoginResponse resp = new LoginResponse(jResp);

            if (resp.Result == LoginResult.Success)
            {
                //Update local storage for user status.
                StorageManager.ClearUserStatus();
                _status = new UserStatus()
                {
                    Expire = jResp.expire,
                    Token = jResp.token,
                    UserID = jResp.user_id
                };

                if (saveStatus)
                {
                    StorageManager.SaveUserStatus(_status);
                }
            }

            return resp;
        }

        /// <summary>
        /// Signs out and remove saved user status if exists.
        /// </summary>
        public void Logout()
        {
            _status = null;
            StorageManager.ClearUserStatus();
        }

        /// <summary>
        /// Indicates if saved user status exists.
        /// </summary>
        public bool LocalUserStatusExists
        {
            get
            {
                return StorageManager.UserStatusExists;
            }
        }

        /// <summary>
        /// Indicates if a valid user has signed in.
        /// </summary>
        public bool HasUserLogin
        {
            get
            {
                return _status != null;
            }
        }

        /// <summary>
        /// Tries to recover user sign-in status from storage.
        /// </summary>
        /// <returns>Returns true if a valid user status 
        /// has been loaded successfully.</returns>
        public bool TryLoadStatus()
        {
            if (LocalUserStatusExists)
            {
                _status = StorageManager.LoadUserStatus();
                return _status != null;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Saves current user sign-in status if exists.
        /// </summary>
        public void SaveStatus()
        {
            if (_status != null)
            {
                StorageManager.SaveUserStatus(_status);
            }
        }

        /// <summary>
        /// Loads last time played channel from local storage.
        /// </summary>
        /// <remarks>
        /// If no saved channel, a default channel will be applied.
        /// </remarks>
        public void LoadLastChannel()
        {
            CurrentChannel = StorageManager.LoadLastChannel();
        }

        /// <summary>
        /// Removes saved last time played channel if exists.
        /// </summary>
        public void ClearLastChannel()
        {
            StorageManager.ClearLastChannel();
        }

        /// <summary>
        /// Saves current playing channel to local storage.
        /// </summary>
        public void SaveCurrentChannel()
        {
            StorageManager.SaveLastChannel(CurrentChannel);
        }

        //Adds songs within response to current playlist.
        private void ExtractPlaylist(PlaylistResponse resp, bool clearList)
        {
            if (resp.Success)
            {
                if (clearList)
                {
                    _playlist.Clear();
                }

                foreach (var item in resp.Songs)
                {
                    _playlist.Enqueue(item);
                }
            }
        }

        //Removes current playing song then adds to play history.
        private Song DequeueToHistory(PlayOperation operationType)
        {
            if (_playlist.Count > 0)
            {
                var song = _playlist.Dequeue();
                _history.AddSong(song, operationType);

                if (_playlist.Count == 1)
                {
                    PlaylistRequest request = new PlaylistRequest(
                        _status, _history, PlayOperation.PlayingLast,
                        CurrentChannel, CurrentSong);

                    var resp = request.GetResponse();

                    ExtractPlaylist(resp, false);
                }

                return song;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets a new playlist.
        /// </summary>
        public void NewList()
        {
            PlaylistRequest request = new PlaylistRequest(
                _status, _history, PlayOperation.NewList, CurrentChannel, null);

            var resp = request.GetResponse();

            ExtractPlaylist(resp, true);
        }

        /// <summary>
        /// Skips current song.
        /// </summary>
        public void Skip()
        {
            var song = DequeueToHistory(PlayOperation.Skip);

            PlaylistRequest request = new PlaylistRequest(
                _status, _history, PlayOperation.Skip, CurrentChannel, song);

            var resp = request.GetResponse();

            ExtractPlaylist(resp, true);
        }

        /// <summary>
        /// Notifies server that current song plays to end, then play next song.
        /// </summary>
        public void Next()
        {
            var song = DequeueToHistory(PlayOperation.PlaysToEnd);

            PlaylistRequest request = new PlaylistRequest(
                _status, _history, PlayOperation.PlaysToEnd, CurrentChannel,
                song);

            request.GetResponse();
        }

        /// <summary>
        /// Switches to another channel, playlist will be updated.
        /// </summary>
        /// <param name="newChannel"></param>
        public void SwitchChannel(Channel newChannel)
        {
            var song = DequeueToHistory(PlayOperation.Skip);

            CurrentChannel = newChannel;

            PlaylistRequest request = new PlaylistRequest(
                _status, _history, PlayOperation.Skip, CurrentChannel, song);

            var resp = request.GetResponse();

            ExtractPlaylist(resp, true);
        }

        /// <summary>
        /// Indicates do not play current song any more.
        /// </summary>
        public void PlayNoMore()
        {
            var song = DequeueToHistory(PlayOperation.Bin);

            PlaylistRequest request = new PlaylistRequest(
                _status, _history, PlayOperation.Bin, CurrentChannel, song);

            var resp = request.GetResponse();

            ExtractPlaylist(resp, true);
        }

        /// <summary>
        /// Indicates user mark current song as a liked-song.
        /// </summary>
        public void Like()
        {
            PlaylistRequest request = new PlaylistRequest(
                _status, _history, PlayOperation.Like, CurrentChannel,
                CurrentSong);

            request.GetResponse();
        }

        /// <summary>
        /// Indicates user unmark current song as a liked-song.
        /// </summary>
        public void Unlike()
        {
            PlaylistRequest request = new PlaylistRequest(
                _status, _history, PlayOperation.Unlike, CurrentChannel,
                CurrentSong);

            request.GetResponse();
        }
    }
}
