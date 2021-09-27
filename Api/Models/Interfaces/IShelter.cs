namespace PeopleManagement.Models
{
    public interface IShelter
    {
        void FindShelter();
        Person UpgradeShelter();
        Person PayForShelter();
    }
}