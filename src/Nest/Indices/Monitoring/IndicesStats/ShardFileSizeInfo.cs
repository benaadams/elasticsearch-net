// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.Runtime.Serialization;

namespace Nest
{
	[DataContract]
	public class ShardFileSizeInfo
	{
		[DataMember(Name ="description")]
		public string Description { get; internal set; }

		[DataMember(Name ="size_in_bytes")]
		public long SizeInBytes { get; internal set; }
	}
}
