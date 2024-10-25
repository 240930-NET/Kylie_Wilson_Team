using System;
using System.Text.Json.Serialization;
namespace TaskManager.Models;
public class ToDo
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;

    public string? Due { get; set; }

    public string State { get; set; } = "In progress";



}