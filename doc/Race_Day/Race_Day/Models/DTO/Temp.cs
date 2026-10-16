C:\Users\Student\Documents\GitHub\Nwayitelo-POE-Part1\doc\Race_Day\Race_Day\Data\DTO\EntityDtos.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace Race_Day.Data.DTO
{
    // -----------------------
    // User DTOs
    // -----------------------
    public class UserDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Role { get; set; }
        public required string Phone { get; set; }
    }

    public class CreateUserDto
    {
        [Required]
        public required string Name { get; set; }

        [Required, EmailAddress]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }

        [Required]
        public required string Role { get; set; }

        [Required, Phone]
        public required string Phone { get; set; }
    }

    public class UpdateUserDto
    {
        public string? Name { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? Role { get; set; }

        [Phone]
        public string? Phone { get; set; }
    }

    // -----------------------
    // Venue DTOs
    // -----------------------
    public class VenueDto
    {
       
        public required string VenuesName { get; set; }
        public required string VenuesLocation { get; set; }
        public required string VenuesCity { get; set; }
        public required string VenuesCapcity { get; set; }
        public required string VenuesProvince { get; set; }
    }

    public class CreateVenueDto
    {
        [Required]
        public required string VenuesName { get; set; }

        [Required]
        public required string VenuesLocation { get; set; }

        [Required]
        public required string VenuesCity { get; set; }

        [Required]
        public required string VenuesCapcity { get; set; }

        [Required]
        public required string VenuesProvince { get; set; }
    }

    public class UpdateVenueDto
    {
        public string? VenuesName { get; set; }
        public string? VenuesLocation { get; set; }
        public string? VenuesCity { get; set; }
        public string? VenuesCapcity { get; set; }
        public string? VenuesProvince { get; set; }
    }

    // -----------------------
    // Race Event DTOs
    // -----------------------
    public class RaceEventDto
    {
        public int Race_EventId { get; set; }
        public int VenueId { get; set; }
        public required string Race_EventName { get; set; }
        public required DateOnly Race_EventDate { get; set; }
        public required string Description { get; set; }
        public required string Race_EventStatus { get; set; }
    }

    public class CreateRaceEventDto
    {
        [Required]
        public int VenueId { get; set; }

        [Required]
        public required string Race_EventName { get; set; }

        [Required]
        public required DateOnly Race_EventDate { get; set; }

        public string? Description { get; set; }

        public string? Race_EventStatus { get; set; }
    }

    public class UpdateRaceEventDto
    {
        public int? VenueId { get; set; }
        public string? Race_EventName { get; set; }
        public DateOnly? Race_EventDate { get; set; }
        public string? Description { get; set; }
        public string? Race_EventStatus { get; set; }
    }

    // -----------------------
    // Registration DTOs
    // -----------------------
    public class RegistrationDto
    {
        public int RegistrationId { get; set; }
        public int Race_EventId { get; set; }
        public int RaceId { get; set; }
        public required string ParticipantName { get; set; }
        public required string ParticipantEmail { get; set; }
        public required string ParticipantPhone { get; set; }
        public required string ParticipantAddress { get; set; }
        public required string ParticipantCity { get; set; }
        public required string ParticipantProvince { get; set; }
        public required string ParticipantPostalCode { get; set; }
    }

    public class CreateRegistrationDto
    {
        [Required]
        public int Race_EventId { get; set; }

        [Required]
        public int RaceId { get; set; }

        [Required]
        public required string ParticipantName { get; set; }

        [Required, EmailAddress]
        public required string ParticipantEmail { get; set; }

        [Required, Phone]
        public required string ParticipantPhone { get; set; }

        [Required]
        public required string ParticipantAddress { get; set; }

        [Required]
        public required string ParticipantCity { get; set; }

        [Required]
        public required string ParticipantProvince { get; set; }

        [Required]
        public required string ParticipantPostalCode { get; set; }
    }

    public class UpdateRegistrationDto
    {
        public int? Race_EventId { get; set; }
        public int? RaceId { get; set; }
        public string? ParticipantName { get; set; }

        [EmailAddress]
        public string? ParticipantEmail { get; set; }

        [Phone]
        public string? ParticipantPhone { get; set; }
        public string? ParticipantAddress { get; set; }
        public string? ParticipantCity { get; set; }
        public string? ParticipantProvince { get; set; }
        public string? ParticipantPostalCode { get; set; }
    }

    // -----------------------
    // Race DTOs
    // -----------------------
    public class RaceDto
    {
        public int Id { get; set; }
        public int Race_EventId { get; set; }
        public required string Race_name { get; set; }
        public required string Race_Number { get; set; }
        public required string Race_distance { get; set; }
        public required TimeOnly Race_time { get; set; }
        public required string Race_Description { get; set; }
    }

    public class CreateRaceDto
    {
        [Required]
        public int Race_EventId { get; set; }

        [Required]
        public required string Race_name { get; set; }

        [Required]
        public required string Race_Number { get; set; }

        [Required]
        public required string Race_distance { get; set; }

        [Required]
        public required TimeOnly Race_time { get; set; }

        public string? Race_Description { get; set; }
    }

    public class UpdateRaceDto
    {
        public int? Race_EventId { get; set; }
        public string? Race_name { get; set; }
        public string? Race_Number { get; set; }
        public string? Race_distance { get; set; }
        public TimeOnly? Race_time { get; set; }
        public string? Race_Description { get; set; }
    }

    // -----------------------
    // Ticket DTOs
    // -----------------------
    public class TicketDto
    {
        public int TicketId { get; set; }
        public int Race_EventId { get; set; }
        public int UserId { get; set; }
        public required string TicketType { get; set; }
        public required decimal TicketPrice { get; set; }
        public string? TicketName { get; set; }
        public string? TicketDescription { get; set; }
        public required DateOnly PurchaseDate { get; set; }
        public required string TicketStatus { get; set; }
    }

    public class CreateTicketDto
    {
        [Required]
        public int Race_EventId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public required string TicketType { get; set; }

        [Required]
        public required decimal TicketPrice { get; set; }

        public string? TicketName { get; set; }
        public string? TicketDescription { get; set; }

        [Required]
        public required DateOnly PurchaseDate { get; set; }

        public string? TicketStatus { get; set; }
    }

    public class UpdateTicketDto
    {
        public int? Race_EventId { get; set; }
        public int? UserId { get; set; }
        public string? TicketType { get; set; }
        public decimal? TicketPrice { get; set; }
        public string? TicketName { get; set; }
        public string? TicketDescription { get; set; }
        public DateOnly? PurchaseDate { get; set; }
        public string? TicketStatus { get; set; }
    }

    // -----------------------
    // Results DTOs
    // -----------------------
    public class ResultsDto
    {
        public int ResultsId { get; set; }
        public int RegistrationId { get; set; }
        public required string ResultsName { get; set; }
        public required string ResultsPosition { get; set; }
        public required string ResultsTime { get; set; }
        public required string ResultsStatus { get; set; }
    }

    public class CreateResultsDto
    {
        [Required]
        public int RegistrationId { get; set; }

        [Required]
        public required string ResultsName { get; set; }

        [Required]
        public required string ResultsPosition { get; set; }

        [Required]
        public required string ResultsTime { get; set; }

        public string? ResultsStatus { get; set; }
    }

    public class UpdateResultsDto
    {
        public int? RegistrationId { get; set; }
        public string? ResultsName { get; set; }
        public string? ResultsPosition { get; set; }
        public string? ResultsTime { get; set; }
        public string? ResultsStatus { get; set; }
    }
}