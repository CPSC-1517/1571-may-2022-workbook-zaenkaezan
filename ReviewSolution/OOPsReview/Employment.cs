using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview.Data
{
    public class Employment
    {
        /* Class Fundamentals:
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
        */
        private string _Title;
        private double _Years;

        /* Property Fundamentals:
            These are access techniques to retrieve or set data in your class without directly touching the storage data field.
            A property is as associated with a single instance of data.
            A property is public so it can be accessed by an outside user of the class.
            A property MUST have a get
            A property MAY have a set, if there is no set, the property is not changeable by the user; it's readonly. Why do that? > Commonly used for calculated data of the class.
            The set can be either public or private.
                public: the user can alter the contents of the data
                private: only code within the class can alter the contents     

        Fully Implemented Property: 
            A declared storage area (data field)
            A declared property signature access rdt(return data type) and property name.
            Properties do not have a list of parameters to put in, they are associated with a single value only.
            A coded accessor (get) coding block : public
            An optional coded mutator (set) coding block : public or private
                If the set is private, the only way to place data into this property is via the constructor or a behaviour (method)
        
        When to use a Fully Implemented Property:
            If you are storing the associate data in an explicitly declard data field
            If you are doing validation on incoming data
            Creating a property that generates output from other data sources within the class (read only property); this property would only have a accessor (get)
        */
        public string Title
        {            
            get
            {
                /* Accessor Fundamentals
                    The get "coding block" will return the contents of a data field(s).
                    The return has syntax of return expression.
                */
                return _Title;
            }
            set
            {              
                /* Mutator Fundamentals
                    The set "coding block" receives an incoming value and places it into the associated data field
                    During the setting, you might wish to validate the incoming data
                    During the setting, you might wish to do some type of logical processing using the data to set another field.
                    The incoming piece of data is referred to using the keyword "value"

                    Ensure that the incoming data is not mull or empty or just white space
                */
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Title is a required piece of data.");
                }

                // if data is considered valid:
                _Title = value;
            }
        }   
        /* Auto Implemented Property:
            These properties differ only in syntax
            Each property is resposible for a single piece of data
            These properties do NOT reference a declared private data member
            The System generates an internal storage area of the return data type
            The System manages the internal storage for the accessor and mutator
            There is no additional logic applied to the data value

            Using an enum for this field will automatically restrict the data values this property can contain

            Syntax: accesstype rdt(return data type) propertyname {get; [private] set;}
        */

        public SupervisoryLevel Level { get; set; }
        public double Years
        {
            get { return _Years; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException($"Years value {value} is invalid. Must be 0 or greater.");
                }
                _Years = value;
            }
        }

        /* Constructor Fundamentals
            This is used to initialize the physical object (instance) during its creation. The result of creation is to ensure that the coder gets an instance in a 'known' state.
            If your class definition has NO constructor coded, then the data members and/or auto implemented properties are set to the C# default data type values

            You can code one or more constructors in your class definiton.
            If you code a constructor for the class, you are responsible for all constructors used by the class. All or nothing scenario.

            Generally, if you are going to code your own constructors you code two types:
                Default: this constructor does not take in any patameters. This constructor mimics the default system constructor.
                Greedy: this constructor has a list of parameters, one for each property, declare for incoming data
            
            Syntax: accesstype classname([list of parameters]) {constructor code block}

            IMPORTANT: This constructor does not have a return datatype.
                        You do not call a constructor directly, it is called using the new command => new classname(...);
        */

        // Default Constructor:
        public Employment()
        {
            /*  Constructor Body:
             *      a. Empty: values will be set to C# defaults
             *      b. You could assign literal values to your properties with this constructor.
             * 
             *  The values that you give your class data members/properties CAN be assigned directly to a data member
             *  HOWEVER, if you have validated properties, you SHOULD consider saving your data values via the property.
             */

            Level = SupervisoryLevel.TeamMember;
            Title = "Unknown";
        }

        // Greedy Constructor
        public Employment(string title, SupervisoryLevel level, double years)
        {
            Title = title;
            Level = level;
            Years = years;
        }

    }
}