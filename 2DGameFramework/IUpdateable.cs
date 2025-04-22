using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGameFramework
{
    // Single responsibility
    public interface IUpdateable
    {
        /// <summary>
        /// This function is called, when it is this objects turn to be updated
        /// </summary>
        public abstract void Update();
    }
}
