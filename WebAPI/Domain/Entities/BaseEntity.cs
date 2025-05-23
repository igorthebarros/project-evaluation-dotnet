﻿using Common.Validation;

namespace Domain.Entities
{
    public class BaseEntity : IComparable<BaseEntity>
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public Task<IEnumerable<ValidationErrorDetail>> ValidateAsync()
        {
            return MainValidator.ValidateAsync(this);
        }
        
        public int CompareTo(BaseEntity? other)
        {
            if (other == null) return 1;

            return other!.Id.CompareTo(Id);
        }
    }
}
