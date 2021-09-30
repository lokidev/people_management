using System;

#nullable disable

namespace PeopleManagement.Models
{
    public interface IPerson : IConsume, IMate, IWork, ISocial, IShelter
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        bool? Gender { get; set; }
        double? Luck { get; set; }
        double? Health { get; set; }
        double? Hunger { get; set; }
        double? Security { get; set; }
        double? AvailableFood { get; set; }
        double? AvailableResources { get; set; }
        int? Mate { get; set; }
        DateTime CreationDate { get; set; }
        DateTime? BirthDate { get; set; }
        DateTime? DeathDate { get; set; }
        DateTime? DestructionDate { get; set; }
        string IdentificationTags { get; set; }
    }
}
