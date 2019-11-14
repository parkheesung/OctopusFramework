# OctopusFramework

> C# Entity Library Based on Microsoft .Net standard Library 2.0

##### OctopusFramework 하위 라이브러리들의 기능을 일관성있게 제공하기 위한 기본 라이브러리 입니다.

### Function

<pre><code>
public class Human : IEntity
{
    [Entity("이름", "Name", Entities.EntityType.String, 30)]
    public string Name { get; set; }

    [Entity("성별", "Gender", Entities.EntityType.String, 10)]
    public string Gender { get; set; }

    [Entity("나이", "Age", Entities.EntityType.Number)]
    public int Age { get; set; }

    public Human()
    {
    }
}

//Model Binding
DataTable dt = { Select your Database Table };
List&lt;Human&gt; list = dt.DataToEntity&lt;Human&gt;();
</code></pre>

### Release

1. Release Date 2019.11.13 Version 0.1
