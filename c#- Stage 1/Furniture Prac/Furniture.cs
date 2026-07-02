class Furniture
{
    int _id;
    string _name;
    // string _color;    can delete bcoz of auto property.
    public int Count;

    internal int Id
    {
        get
        {
            return _id;
        }
        set
        {
            _id=value;
        }
    }
    internal string Name{get{return _name;}set{_name=value;}}

    internal string Color{get;set;}    //Auto property. poora poora likhne ke bajae ae krdo bs _color-->Color ho jaega. pehla bada or underscore htado. Auto peroperty me no need to declare backing field.  we can delete _color now, it is self declared also.

     
}