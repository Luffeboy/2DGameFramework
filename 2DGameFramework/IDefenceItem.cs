using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGameFramework
{
    public interface IDefenceItem : INamed
    {
        int ReduceHitPoints();
        /// <summary>
        /// Returns the IDefenceItem, that results in adding an IDefenceItem to this
        /// </summary>
        /// <param name="defenceItem">The IDefenceItem</param>
        /// <returns></returns>
        IDefenceItem AddIDefenceItem(IDefenceItem defenceItem);
    }
}
