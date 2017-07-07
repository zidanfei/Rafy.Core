﻿using System;
using System.IO;

namespace Rafy.Serialization
{
    /// <summary>
    /// Defines an object that can serialize and deserialize
    /// object graphs.
    /// </summary>
    public interface ISerializationFormatter
    {
        /// <summary>
        /// Converts a serialization stream into an
        /// object graph.
        /// </summary>
        /// <param name="serializationStream">
        /// Byte stream containing the serialized data.</param>
        /// <returns>A deserialized object graph.</returns>
        object Deserialize(Stream serializationStream);

        /// <summary>
        /// Converts an object graph into a byte stream.
        /// </summary>
        /// <param name="serializationStream">
        /// Stream that will contain the the serialized data.</param>
        /// <param name="graph">Object graph to be serialized.</param>
        void Serialize(Stream serializationStream, object graph);
    }
}
