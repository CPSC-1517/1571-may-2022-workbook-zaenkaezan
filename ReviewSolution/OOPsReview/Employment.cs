using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview.Data
{
    public class Employment
    {
        /* Class Fundamentals
        An instance of this class will hold data about a person's employment. The code of this class is the definition of that data.

        The characteristics (data) of the class:
            Title, SupervisorLevel, Years of Employment within the company.

        There are 4 components of a class definition:
            Data Fields (Data Members)
            Property
            Constructor
            Behaviour (Method)

        Data Fields:
            Are storage areas in your class 
            These are treated as variable
            They could be public, private, public readonly

        Property:
            These are access techniques to retrieve or set data in your class without directly touching the storage data field.
            A property is as associated with a single instance of data.
            A property is public so it can be accessed by an outside user of the class.
            A property MUST have a get
            A property MAY have a set, if there is no set, the property is not changeable by the user; it's readonly. Why do that? > Commonly used for calculated data of the class.
            The set can be either public or private.
                public: the user can alter the contents of the data
                private: only code within the class can alter the contents     
        */

        public string Title
        {
            get;
            set;
        }
    }
}
