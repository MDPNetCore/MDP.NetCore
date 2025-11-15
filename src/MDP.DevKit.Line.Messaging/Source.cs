using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDP.DevKit.LineMessaging
{
    public abstract class Source
    {
        // Constructors
        protected Source(string sourceType)
        {
            #region Contracts

            if (string.IsNullOrEmpty(sourceType) == true) throw new ArgumentException($"{nameof(sourceType)}=null");

            #endregion

            // Default
            this.SourceType = sourceType;
        }


        // Properties
        public string SourceType { get; } = string.Empty;
    }
}
