﻿namespace Simple.Rest.Tests.Dto
{
    using System;

    public class Employee : IEquatable<Employee>
    {
        public bool Equals(Employee other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Employee) obj);
        }

        public override int GetHashCode()
        {
            return Id ?? 0;
        }

        public static bool operator ==(Employee left, Employee right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Employee left, Employee right)
        {
            return !Equals(left, right);
        }

        public int? Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
