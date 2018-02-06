using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emlak
{
    class SingletonClass
    {
       
    }

    public class SingletonClassEvEkleme
    {
        private static EvEkleme EvEkleAnaMenu;
        protected SingletonClassEvEkleme() { }

        public static EvEkleme MainMenuEvEkleme()
        {
            if (EvEkleAnaMenu==null ||EvEkleAnaMenu.IsDisposed)
            {
                EvEkleAnaMenu = new EvEkleme();
            }
            return EvEkleAnaMenu;
        }
    }

    public class SingletonClassEvSorgulamaListeleme
    {
        private static EvListelemeSorgulama evSorgulama;
        protected SingletonClassEvSorgulamaListeleme() { }

        public static EvListelemeSorgulama SorgulamaEkraniAc()
        {
            if (evSorgulama == null || evSorgulama.IsDisposed)
            {
                evSorgulama = new EvListelemeSorgulama();
            }
            return evSorgulama;
        }
    }

    public class SinglethonClassMusteriSorgu
    {
        private static SatilanKiralananEvler musteriSorgu;
        protected SinglethonClassMusteriSorgu() { }

        public static SatilanKiralananEvler SorgulamaEkraniAc()
        {
            if (musteriSorgu == null || musteriSorgu.IsDisposed)
            {
                musteriSorgu = new SatilanKiralananEvler();
            }
            return musteriSorgu;
        }
    }

}
