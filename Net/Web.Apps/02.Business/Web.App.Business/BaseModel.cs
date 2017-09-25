using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Represents the Base Model Class
/// </summary>
namespace Web.App.Business
{
    /// <summary>
    /// The Base Model
    /// </summary>
    public class BaseModel
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseModel"/> class.
        /// </summary>
        public BaseModel()
        {

        }
        #endregion

        #region Overridable Members
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public virtual string Type { get { return this.Type = string.Format("{0}-{1}", this.GetType().Assembly.GetName().ToString(), this.GetType().Name); } set { this.Type = value; } }
        #endregion

        #region Public Members
        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        /// <value>
        /// The unique identifier.
        /// </value>
        public Guid GUID { get; set; }

        /// <summary>
        /// Gets or sets the created at UTC.
        /// </summary>
        /// <value>
        /// The created at UTC.
        /// </value>
        public DateTime CreatedAtUTC { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is deleted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is deleted; otherwise, <c>false</c>.
        /// </value>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets the updated at UTC.
        /// </summary>
        /// <value>
        /// The updated at UTC.
        /// </value>
        public DateTime UpdatedAtUTC { get; set; }
        #endregion

        #region Private Members
        /// <summary>
        /// Gets or sets the hash set.
        /// </summary>
        /// <value>
        /// The hash set.
        /// </value>
        private HashSet<BaseModel> HashSet { get; set; }

        /// <summary>
        /// Gets or sets the serialized data.
        /// </summary>
        /// <value>
        /// The serialized data.
        /// </value>
        private string SerializedData { get; set; }

        /// <summary>
        /// Gets or sets the deserialized data.
        /// </summary>
        /// <value>
        /// The deserialized data.
        /// </value>
        private BaseModel DeserializedData { get; set; }
        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the hash.
        /// </summary>
        /// <returns>
        /// The Hash Set of type
        /// </returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Gets the serialized data.
        /// </summary>
        /// <returns>
        /// The Serialized String data
        /// </returns>
        public virtual string GetSerializedData()
        {
            return this.SerializedData = JsonConvert.SerializeObject(this);
        }

        /// <summary>
        /// Gets the deserialzed data.
        /// </summary>
        /// <returns></returns>
        public virtual BaseModel GetDeserialzedData()
        {
            return this.DeserializedData = this;
        }

        /// <summary>
        /// Adds to hash set.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>
        /// The Hash Set with newly added item
        /// </returns>
        /// <exception cref="System.NullReferenceException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        public virtual HashSet<BaseModel> AddToHashSet(BaseModel obj)
        {
            if (this.HashSet == null)
                this.HashSet = new HashSet<BaseModel>();
            if (obj == null)
                throw new ArgumentNullException();
            this.HashSet.Add(obj);

            return this.HashSet;
        }

        /// <summary>
        /// To the dictionary.
        /// </summary>
        /// <returns>
        /// The Dictionary from the Hash Set of T
        /// </returns>
        /// <exception cref="System.NullReferenceException">HashSet is null</exception>
        public virtual IDictionary<Guid, BaseModel> ToDictionary()
        {
            var dictionary = new Dictionary<Guid, BaseModel>();
            if (this.HashSet == null)
                throw new NullReferenceException("HashSet is null");
            foreach (var key in this.HashSet)
            {
                dictionary.Add(key.GUID, this.HashSet.FirstOrDefault(x => x.GUID == key.GUID));
            }

            return dictionary;
        }
        #endregion
    }
}
