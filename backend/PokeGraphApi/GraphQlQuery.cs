using System.Text;

namespace PokeGraphApi;

public class GraphQlQuery
{
    private readonly StringBuilder _queryBuilder = new();

    public GraphQlQuery(string queryName)
    {
        _queryBuilder.Append($"query {queryName}{{");
    }

    public GraphQlQuery Field(string fieldName)
    {
        _queryBuilder.Append($"{fieldName} ");

        return this;
    }

    public GraphQlQuery Field(string fieldName, Action<GraphQlQuery> subBuilder)
    {
        _queryBuilder.Append($"{fieldName}{{");
        subBuilder(this);
        _queryBuilder.Append('}');

        return this;
    }

    public GraphQlQuery FieldWithArguments(string fieldName, Action<GraphQlQuery> subBuilder)
    {
        _queryBuilder.Append($"{fieldName}(");
        subBuilder(this);
        _queryBuilder.Append('}');

        return this;
    }

    public GraphQlQuery Argument(string argumentName, Action<GraphQlQuery> subBuilder)
    {
        _queryBuilder.Append($"{argumentName}:{{");
        subBuilder(this);
        _queryBuilder.Append('}');

        return this;
    }

    public GraphQlQuery ArgumentCondition(string operatorName, string value)
    {
        _queryBuilder.Append($"{operatorName}:\"{value}\"");

        return this;
    }

    public GraphQlQuery ArgumentCondition(string operatorName, int value)
    {
        _queryBuilder.Append($"{operatorName}:{value}");

        return this;
    }

    public GraphQlQuery ArgumentConditionEnum(string operatorName, string value)
    {
        _queryBuilder.Append($"{operatorName}:{value}");

        return this;
    }

    public GraphQlQuery EndArguments()
    {
        _queryBuilder.Append("){");

        return this;
    }

    public string Build() => _queryBuilder.Append('}').ToString();
}