# COMPONENT-DOCUMENTS-DOC - HOW TO USE

Welcome to this awesome component !!!

You will be able to generate and read your documents very easily.



## REPLACE ALL THE VARIBLES OF THE TEMPLATE


### THE TEMPLATE

You have a template witch is a **Word** document with variables which you want to replace with your data.  
The variables in the document should be like this :  
  
> ${EXAMPLE}


> [!CAUTION]
> The document must have only the **.docx** extension, or it will not work


  
In this case our document is named `exampleDoc.docx`  
and it looks like this :  
  
> This is a document and I want to replace this variable ${VARIABLE_EXAMPLE} and  
  also this one ${NUMBER}.
  
  
You will then need a DTO **Object** that contains all the document data to replace in the template.  
In this example we have the `ExampleTemplate.java` and looks like this :

```   
		@Getter
		@Setter
		public class ExampleTemplate extends GenerableDocument
		{
			private String variable_example = "(I am a replaced variable) ";
			private Integer number = 69;
		}
```
	
	
With this two items we are ready.  
  
  
    
    
  	
### THE REPLACEMENT
		
To replace our variables 

		

