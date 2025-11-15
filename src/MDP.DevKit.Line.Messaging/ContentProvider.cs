using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDP.DevKit.LineMessaging
{
    public abstract class ContentProvider
    {
        // Constructors
        protected ContentProvider(string contentProviderType)
        {
            #region Contracts

            if (string.IsNullOrEmpty(contentProviderType) == true) throw new ArgumentException($"{nameof(contentProviderType)}=null");

            #endregion

            // Default
            this.ContentProviderType = contentProviderType;
        }


        // Properties
        public string ContentProviderType { get; } = string.Empty;
    }
}
