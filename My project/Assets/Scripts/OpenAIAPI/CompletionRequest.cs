using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.OpenAIAPI
{
	public class CompletionRequest
	{
		public string model { get; set; }
		public List<GPTMessage> messages { get; set; }
		public double temperature { get; set; }
		public int max_tokens { get; set; }

	}
}
