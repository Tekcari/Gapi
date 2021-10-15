using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System.Collections.Generic;
using Tekcari.Genapi.Transformation;

namespace Tekcari.Genapi.Tests
{
	[TestClass]
	public class SerializationTest
	{
		[DataTestMethod]
		[DynamicData(nameof(GetSpecifications), DynamicDataSourceType.Method)]
		public void Can_convert_file_to_openapi_spec_model(string filePath)
		{
			var document = DocumentLoader.Read(filePath);
			document.ShouldNotBeNull();
		}

		#region Backing Members

		private static IEnumerable<object[]> GetSpecifications()
		{
			foreach (var file in TestData.GetFilePaths("*.yml"))
				yield return new object[] { file };

			foreach (var file in TestData.GetFilePaths("*.json"))
				yield return new object[] { file };

			var urls = new string[]
			{
				"https://raw.githubusercontent.com/plaid/plaid-openapi/master/2020-09-14.yml"
			};
			foreach (string u in urls) yield return new object[] { u };
		}

		#endregion Backing Members
	}
}