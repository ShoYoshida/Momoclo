using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.EntityClient;

namespace Momoclo.Common
{
    public class DBUtil
    {
        private MomocloEDMContainer container;

        public MomocloEDMContainer MContainer {
            get 
            {
                if (container == null)
                {
                    container = new MomocloEDMContainer();
                }

                return container;
                
            }


        }

    }
}