﻿namespace Company.Models;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Patronymic { get; set; }
    public int Salary { get; set; }
    public int PositionId { get; set; }
}
