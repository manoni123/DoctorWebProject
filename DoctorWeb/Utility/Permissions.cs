using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWeb.Utility
{
    public class Permissions
    {
        // 1 for manager
        // 2 for secretery
        // 3 for terapist

        public void PermissionByGroup(int type) {
            int groupID = type;

            switch (groupID) {
                case 2:

                break;

                case 3:

                break;

            }
        }
    }
}
