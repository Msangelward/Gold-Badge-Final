using Challenge_3_Komodo_Insurance_BadgesPOCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3_Komodo_Insurance_BadgesRepository
{
    public class BadgeRepository
    {
        //Create a dictionary of Badges.
        //Key for the dictionary will be the BadgeID
        //The value for the dictionary will be the List of Door Names.
        //Create a new badge
        //Update Doors on the existing badge
        //Delete All Doors from existing badge
        //Show a list w/all badge numbers and door access

        private Dictionary<int, List<string>> _badgeDictionary = new Dictionary<int, List<string>>();
        private List<Badge> _listOfBadges = new List<Badge>();


        //Create
        public void AddNewBadgeToDictionary(Badge badge)
        {
            _badgeDictionary.Add(badge.BadgeID, badge.AccessibleDoors);
        }

        public void AddNewBadgeToList(Badge badge)
        {
            _listOfBadges.Add(badge);
        }


        //Read
        public Dictionary<int, List<string>> GetDictionary()
        {
            return _badgeDictionary;
        }


        public List<Badge> GetBadges()
        {
            return _listOfBadges;
        }


        //Update
        public bool UpdateExistingBadge(int originalBadgeID, Badge newBadge)
        {

            //find the content
            Badge oldBadge = GetBadgeByID(originalBadgeID);

            //update the content
            if (oldBadge != null)
            {
                oldBadge.BadgeID = newBadge.BadgeID;
                oldBadge.AccessibleDoors = newBadge.AccessibleDoors;
                return true;

            }
            else
            {
                return false;
            }


        }
        //Delete
        public bool RemoveDoorsFromBadge(int badgeID, string nameOfDoor)
        {
            Badge badge = GetBadgeByID(badgeID);
            if (badge == null)
            {
                return false;
            }
            else
            {
                badge.AccessibleDoors.Clear();
            }

            int initialCount = _listOfBadges.Count;
            _listOfBadges.Remove(badge);

            if (initialCount > _listOfBadges.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //Helper
        public Badge GetBadgeByID(int badgeID)
        {
            foreach (Badge badge in _listOfBadges)
            {
                if (badge.BadgeID == badgeID)
                {
                    return badge;
                }
            }
            return null;
        }
    }
}
