namespace MtgInventoryManager.Models.Abstractions;

public interface IDatabaseContextFactory
{
    IDatabaseContext Create(bool isReadOnly = false);
}