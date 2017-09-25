﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Salesman
{
    public Salesman(string name)
    {
        Name = name;
        Customers = new List<Customer>();
    }

    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    public List<Customer> Customers { get; set; }
}
