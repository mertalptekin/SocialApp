using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.BL.DataService
{
    public class UnitOfWork:IDisposable
    {
        #region Setter
        private bool _disposed;
        private AppUserService _appuserService;
        private CommentService _commentService;
        private ShareService _shareService;
        private ShareImageService _shareImageService;
        private ShareVideoService _shareVideoService;
        private UserImageService _userImageService;
        private UserVideoService _uservideoService;

        #endregion

        #region Getter

        public AppUserService AppUserService { get { return _appuserService ?? new AppUserService(); } }
        public CommentService CommentService { get { return _commentService ?? new CommentService(); } }

        public ShareService ShareService { get { return _shareService ?? new ShareService(); } }
        public ShareImageService ShareImageService { get { return _shareImageService ?? new ShareImageService(); } }

        public ShareVideoService ShareVideoService { get { return _shareVideoService ?? new ShareVideoService(); } }

        public UserImageService UserImageService { get { return _userImageService ?? new UserImageService(); } }

        public UserVideoService UserVideoService { get { return _uservideoService ?? new UserVideoService(); } }

        #endregion

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!_disposed)
                {
                    this.Dispose();
                    _disposed = true;
                }
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
