﻿using System;
using System.Linq.Expressions;
using Newtonsoft.Json;

namespace Nest
{
	[JsonObject(MemberSerialization.OptIn)]
	[JsonConverter(typeof(ProcessorJsonConverter<GsubProcessor>))]
	public interface IGsubProcessor : IProcessor
	{
		[JsonProperty("field")]
		Field Field { get; set; }

		[JsonProperty("pattern")]
		string Pattern { get; set; }

		[JsonProperty("replacement")]
		string Replacement { get; set; }
	}

	public class GsubProcessor : ProcessorBase, IGsubProcessor
	{
		public Field Field { get; set; }

		public string Pattern { get; set; }

		public string Replacement { get; set; }
		protected override string Name => "gsub";
	}

	public class GsubProcessorDescriptor<T>
		: ProcessorDescriptorBase<GsubProcessorDescriptor<T>, IGsubProcessor>, IGsubProcessor
		where T : class
	{
		protected override string Name => "gsub";

		Field IGsubProcessor.Field { get; set; }
		string IGsubProcessor.Pattern { get; set; }
		string IGsubProcessor.Replacement { get; set; }

		public GsubProcessorDescriptor<T> Field(Field field) => Assign(field, (a, v) => a.Field = v);

		public GsubProcessorDescriptor<T> Field(Expression<Func<T, object>> objectPath) =>
			Assign(objectPath, (a, v) => a.Field = v);

		public GsubProcessorDescriptor<T> Pattern(string pattern) => Assign(pattern, (a, v) => a.Pattern = v);

		public GsubProcessorDescriptor<T> Replacement(string replacement) => Assign(replacement, (a, v) => a.Replacement = v);
	}
}