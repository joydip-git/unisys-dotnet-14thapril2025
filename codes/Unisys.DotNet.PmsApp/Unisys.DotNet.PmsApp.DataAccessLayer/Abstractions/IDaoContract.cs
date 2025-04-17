namespace Unisys.DotNet.PmsApp.DataAccessLayer.Abstractions
{
    /// <summary>
    /// contract containing common methods for every dao
    /// </summary>
    /// <typeparam name="T">
    /// T represents type used by this dao and it should be a reference type
    /// </typeparam>
    /// <typeparam name="TKey">
    /// TKey reoresents the data type of the unique identifier of the record type (T)
    /// </typeparam>
    public interface IDaoContract<T, TKey> where T : class
    {
        /// <summary>
        /// method to return all records
        /// </summary>
        /// <returns>
        /// collection of records of type T
        /// </returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// method to fetch a single record for a given id
        /// </summary>
        /// <param name="uniqueId">
        /// unique id of the record to fetch
        /// </param>
        /// <returns>
        /// the record or null in case the record is not found
        /// </returns>
        T? Get(TKey uniqueId);

        /// <summary>
        /// method to add a new record
        /// </summary>
        /// <param name="entity">
        /// the object/record to add
        /// </param>
        /// <returns>
        /// true if successfully added otherwise false
        /// </returns>
        bool Insert(T entity);

        /// <summary>
        /// method to update an existing record for given id value
        /// </summary>
        /// <param name="updatedEntity">
        /// the object/record with updated data
        /// </param>
        /// <param name="uniqueId">
        /// unique id of the record to update
        /// </param>
        /// <returns>
        /// true if successfully updated otherwise false
        /// </returns>
        bool Update(TKey uniqueId, T updatedEntity);

        /// <summary>
        /// method to delete a single record for a given id
        /// </summary>
        /// <param name="uniqueId">
        /// unique id of the record to delete
        /// </param>
        /// <returns>
        /// true if successfully deleted otherwise false
        /// </returns>
        bool Delete(TKey uniqueId);
    }
}
