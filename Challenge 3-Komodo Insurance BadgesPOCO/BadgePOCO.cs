using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3_Komodo_Insurance_BadgesPOCO
{
    public class Badge
    {
        //employee badge (dictionary) will have badge# that gives
        //access to a specific list of doors. Ex: Developer-A1, A5,
        //Ex 2: Claims Agent-B2 & B4
        //Create Badge Class with BadgeID (int) and List of Door Names(strings)

        public int BadgeID { get; set; }
        public List<string> AccessibleDoors = new List<string>();

        public Badge() { }

        public Badge(int badgeID, List<string> accessibleDoors)
        {
            BadgeID = badgeID;
            AccessibleDoors = accessibleDoors;
        }
    } 
}
