using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DBApproach.Domain.Base
{
    public interface IEntityBase<TKey>
    {
        
    }

    public interface IDeleteEntity
    {
        
    }

    public interface IDeleteEntity<TKey> : IDeleteEntity, IEntityBase<TKey>
    {
    }

    public interface IAuditEntity
    {
        
    }
    public interface IAuditEntity<TKey> : IAuditEntity, IDeleteEntity<TKey>
    {
    }

    public abstract class EntityBase<TKey> : IEntityBase<TKey>
    {
        
    }

    public abstract class DeleteEntity<TKey> : EntityBase<TKey>, IDeleteEntity<TKey>
    {
        
    }

    public abstract class AuditEntity<TKey> : DeleteEntity<TKey>, IAuditEntity<TKey>
    {
        
    }
}

