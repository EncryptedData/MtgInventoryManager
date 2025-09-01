namespace MtgInventoryManager.Models.Abstractions;

public interface IModelConverter<TPersistence, TTransfer>
    where TPersistence : IPersistEntity
    where TTransfer : ITransferEntity
{
    TPersistence ToPersistenceModel(TTransfer model);

    TTransfer ToTransferModel(TPersistence model);

    TPersistence UpdatePersistenceModel(TPersistence? originalModel, TTransfer transferModel);
}