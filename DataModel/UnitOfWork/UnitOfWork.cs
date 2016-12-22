using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.GenericRepository;
using DataModel.SQLDatabase;

namespace DataModel.UnitOfWork
{
    /// <summary>
    /// Unit of Work class responsible for DB transactions
    /// </summary>
    public class UnitOfWork : IDisposable
    {
        #region Private member variables...

        private SimplerNewsSQLDb _context = null;
        private IGenericRepository<YoutubeChannel> _youtubeChannelRepository;
        private IGenericRepository<VideoCategory> _videoCategoryRepository;
        private IGenericRepository<Video> _videoRepository;
        private IGenericRepository<User> _userRepository;
        private IGenericRepository<UserVideoWatched> _userVideoWatchedRepository;
        #endregion

        public UnitOfWork()
        {
            _context = new SimplerNewsSQLDb();
        }

        #region Public Repository Creation properties...

        public IGenericRepository<YoutubeChannel> YoutubeChannelRepository
        {
            get
            {
                if (this._youtubeChannelRepository == null)
                    this._youtubeChannelRepository = new GenericRepositorySQL<YoutubeChannel>(_context);
                return _youtubeChannelRepository;
            }
        }

        public IGenericRepository<Video> VideoRepository
        {
            get
            {
                if (this._videoRepository == null)
                    this._videoRepository = new GenericRepositorySQL<Video>(_context);
                return _videoRepository;
            }
        }

        public IGenericRepository<VideoCategory> VideoCategoryRepository
        {
            get
            {
                if (this._videoCategoryRepository == null)
                    this._videoCategoryRepository = new GenericRepositorySQL<VideoCategory>(_context);
                return _videoCategoryRepository;
            }
        }

        public IGenericRepository<User> UserRepository
        {
            get
            {
                if (this._userRepository == null)
                    this._userRepository = new GenericRepositorySQL<User>(_context);
                return _userRepository;
            }
        }

        public IGenericRepository<UserVideoWatched> UserVideoWatchedRepository
        {
            get
            {
                if (this._userVideoWatchedRepository == null)
                    this._userVideoWatchedRepository = new GenericRepositorySQL<UserVideoWatched>(_context);
                return _userVideoWatchedRepository;
            }
        }
        #endregion

        #region Public member methods...
        /// <summary>
        /// Save method.
        /// </summary>
        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {

                var outputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Add(string.Format(
                        "{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now,
                        eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                    }
                }
                System.IO.File.AppendAllLines(@"C:\errors.txt", outputLines);

                throw e;
            }

        }

        #endregion

        #region Implementing IDiosposable...

        #region private dispose variable declaration...
        private bool disposed = false;
        #endregion

        /// <summary>
        /// Protected Virtual Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Debug.WriteLine("UnitOfWork is being disposed");
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
