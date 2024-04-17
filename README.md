# COMPONENT-DOCUMENTS-DOC - HOW TO USE

Welcome to this awesome component !!!

You will be able to generate and read your documents very easily.

<br>

## REPLACE ALL THE VARIBLES OF THE TEMPLATE

### THE TEMPLATE

<br>

You have a template witch is a **Word** document with variables which you want to replace with your data.  
The variables in the document should be like this :  

> ${EXAMPLE}

<br>

> [!CAUTION]
> The document must have only the **.docx** extension, or it will not work.

<br>
<br>

In this case our document is named `exampleDoc.docx`  
and it looks like this :  

<br>

> This is a document and I want to replace this variable ${VARIABLE_EXAMPLE} and  
> also this one ${NUMBER}.

<br>
<br>

You will then need a DTO **Object** that contains all the document data to replace in the template.  
In this example we have the `ExampleTemplate.java` that extends of `GenerableDocument` and looks like this :

```java
		@Getter
		@Setter
		public class ExampleTemplate extends GenerableDocument
		{
			private String variableExample = "(I am a replaced variable)";
			private String number = "69";
		}
```
> [!CAUTION]
> In the **Java Class** the varible name must be in camelCase as `variableExample` while in the .docx file
> should look like `${VARIABLE_EXAMPLE}`, otherwise it doesn't work.

<br>

With this two items we are ready.  

<br>
<br>

### THE REPLACEMENT

<br>

To replace our variables we need the `DocxDocumentService`.

```java
	@Autowired
	private DocxDocumentService service;
```
<br>

We initialize the class that contains the data.

```java
	private ExampleTemplate exampleDto = new ExampleTemplate ( );
```

<br>

Then we need a **File** object with the current template.

```java
	File templateFile = FileUtils.loadFileFromResources ( "/templates/exampleDoc.docx" );
```

In this case our template is located in a folder called templates within the project resources folder.

<br>

Then we need an output folder with an output empty file, in this case this will be the path with the empty file.

```java
	private String outputPath = "src/main/resources/templateOutput/exampleDoc_output.docx";
```

<br>

Finally we call the writeFile method from Docx Document Service and pass in parameters the `templateFile`, `outputPath` and `exampleDto`.
This method will return an `Optional` of `File`.

```java
	Optional < File > output = service.writeFile ( templateFile, outputPath, exampleDto );
```

It generates the final document with the replaced variables and in the `Optional` we have the `File` object of the **output document**.

<br>

The result will look like this.

> This is a document and I want to replace this variable (I am a replaced variable) and  
> also this one 69.

<br>

## VARIABLE TYPES

In your class that extends GenerableDocument you can use all of these variables.

<br>

### String Variable

You can use `String` to repalce in the .docx file.

| In the Java Class  | In the .doxc File |
| ------------- | ------------- |
| `private String example = " Hello! "`  | ${EXAMPLE} |

<br>

### ListDTO Varaible

You can use `ListDTO` to replace the variable for a list.
This is the ListDTO Class : 

```java
		@Getter
		@Setter
		@Builder
		public class ListDTO
		{
			@Builder.Default
			private final List < String > lines = new ArrayList <> ( );
		
			@Builder.Default
			private final ListStyleDTO listStyleDto = ListStyleDTO.builder ( )
					.build ( );
		}
```

<br>

We declare our ListDTO :

```java
	List < String > exampleList = new ArrayList <> ( );
	exampleList.add ( "Example 1" );
	exampleList.add ( "Example 2" );
	exampleList.add ( "Example 3" );
	exampleList.add ( "Example 4" );
	
	private ListDTO example = ListDTO.builder ( )
					.lines ( exampleList )
					.build ( );
```

<br>

Then in the .docx output after replace our ${EXAMPLE} we get this result:

> + Example 1
> + Example 2
> + Example 3
> + Example 4

<br>

### ParagraphDTO Varaible

We can use ParagraphDTO to insert a paragraph.
This is the class :

```java
	@Getter
	@Setter
	@Builder
	public class ParagraphDTO
	{
		private String header;
	
		private String text;
	}
```

<br>

We declare our ListDTO :

```java
	private String headerExample = "Title Example";
	private String textExample = "This a a text example";
	private ParagraphDTO example =  ParagraphDTO.builder().header( headerExample ).text( textExample ).build();
```

<br>

Then in the .docx output after replace our ${EXAMPLE} we get this result:

> <span style="font-size:3em;">Title Example</span>  
> This a a text example
