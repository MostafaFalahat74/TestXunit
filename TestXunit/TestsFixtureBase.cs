using System;
using System.Collections.Generic;
using System.Text;

namespace TestXunit
{
    public abstract class TestsFixtureBase
    {
        private Dictionary<string, object> scenarionContext = new Dictionary<string, object>();
        protected TestsFixtureBase()
        {

        }

        protected void SetObjectToScenarioContext<T>(string key, T @object)
        {
            scenarionContext[key] = @object;
        }

        protected T GetObjectToScenarioContext<T>(string key)
        {
          return (T)scenarionContext[key];
        }



      

    }
}
