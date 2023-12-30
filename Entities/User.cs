using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Entities;

namespace WebApi;

public class User
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public int JobId { get; set; }

    public Job Job { get; set; }
}