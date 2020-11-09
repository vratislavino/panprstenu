using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanPrstenuDveVeze
{
    /// <summary>
    ///     Používá se u každého objektu, který jde vykreslit
    /// </summary>
    public interface IDrawable
    {
        /// <summary>
        ///     Funkce slouží k vykreslení
        /// </summary>
        /// <param name="g">Graphics, který vykresluje konkrétní objekty</param>
        void Draw(Graphics g);
    }
}
