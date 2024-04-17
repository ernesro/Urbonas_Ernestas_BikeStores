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
> should look like `${VARIABLE_EXAMPLE}` or `${VARIABLEEXAMPLE}`, otherwise it doesn't work.

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
To load the file in all these cases we have a utility class, you can create your own or create one like this and use it:

```java
	@UtilityClass
	@Slf4j
	public class FileUtils
	{
		public File loadFileFromResources ( String fileFullPath )
		{
			File output = null;
	
			try
			{
				output = new File ( FileUtils.class.getClassLoader ( )
						.getResource ( fileFullPath )
						.toURI ( ) );
			}
			catch ( Exception e )
			{
				LOGGER.error ( e.getMessage ( ) );
			}
	
			return output;
		}
	}
```

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
We only need a `List` of `String` where each element of the list is a line in the `.docx`

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
We only need two `Strings`, the header and the text.

```java
	private String headerExample = "TITLE EXAMPLE";
	private String textExample = "This a a text example";
	private ParagraphDTO example =  ParagraphDTO.builder().header( headerExample ).text( textExample ).build();
```

<br>

Then in the .docx output after replace our ${EXAMPLE} we get this result:   

> **TITLE EXAMPLE**
> 
> This is a text example

<br>
<br>

### TableDTO Varaible

We can use TableDTO to insert a table.
This is the class :

```java
	@Getter
	@Setter
	@Builder
	public class TableDTO
	{
		@Builder.Default
		private final List < String > headers = new ArrayList <> ( );
	
		@Builder.Default
		private HeaderPosition headerPosition = HeaderPosition.TOP;
	
		@Builder.Default
		private final String[ ][ ] data = new String[0][0];
	
		@Builder.Default
		private TableStyleDTO styles = TableStyleDTO.builder ( )
				.build ( );
	}
```

> [!NOTE]
> **HeaderPosition** is an enum and can be TOP or LEFT depending on your table.

<br>

We declare our TableDTO :
We need a list of strings containing the headers and a 2-dimensional array specifying the columns and rows of the table  
and the contents of these cells.

```java
	List < String > headers = new ArrayList <> ( );
	headers.add ( "HEADER 1" );
	headers.add ( "HEADER 2" );
	headers.add ( "HEADER 3" );
	headers.add ( "HEADER 4" );

	String[ ][ ] data = new String[2][4];
	String[ ] data1 = { "Numbers", "11", "222", "3333" };
	data[0] = data1;

	String[ ] data2 = { "Letters", "AA", "BBB", "CCCC" };
	data[1] = data2;

	private TableDTO example = TableDTO.builder ( )
					.headers ( headers )
					.headerPosition ( HeaderPosition.TOP )
					.data ( data )
					.build ( );
```

<br>

Then in the .docx output after replace our ${EXAMPLE} we get this result :   
![Captura](https://github.com/ernesro/Urbonas_Ernestas_BikeStores/assets/98971981/1dcec841-5f88-4408-bd0c-975a111e9999)

<br>
<br>

### DocumentDTO Varaible

We can use TableDTO to insert a table.
This is the class :

```java
	@Getter
	@Setter
	@Builder
	public class DocumentDTO
	{
		private File document;
	
		@Builder.Default
		private final Map < String, Object > variables = new HashMap <> ( );
	}
```

<br>

Then we declare the DocumentDTO : 
We need a `File object` of the template and a `Map` containg the `name of the varible as a String` and the `DTO object as an Object`


```java
	String example = "HELLO";

	private TableDTO exampleTable = TableDTO.builder ( )		// This is the previous example of table
					.headers ( headers )
					.headerPosition ( HeaderPosition.TOP )
					.data ( data )
					.build ( );

	private ListDTO exampleList = ListDTO.builder ( )		// This is the previous example of list
					.lines ( exampleList )
					.build ( );

	private Map < String, Object > variables = new HashMap <> ( );	// Put the DTOs in the map
	variables.put("EXAMPLE", example);
	variables.put("EXAMPLE_TABLE", example);
	variables.put("EXAMPLE_LIST", example);

	DocumentDTO EXAMPLE = DocumentDTO.builder ( )
					.document ( FileUtils.loadFileFromResources ( "./templateResources/document.docx" ) )
					.variables ( variables )
					.build ( );
```
> [!CAUTION]
> If our `ListDTO` in the `DocumentDTO` is named `exampleList`, in the `.docx file` must be `${EXAMPLE_LIST}` or `${EXAMPLELIST}`. And in the `Map` the string containing the name of the varible must be like `EXAMPLE_LIST` or `EXAMPLELIST`.

Then in the .docx output our `${EXAMPLE}`will be replaced with all the content of `document.docx` and all the `document.docx` variables will be replaced also with the `map` content.

<br>

You can also insert a `list` of `DocumentDTO`,
We declare all the DocumentDTO : 

```java
	DocumentDTO example1 = DocumentDTO.builder ( )
					.document ( FileUtils.loadFileFromResources ( "./templateResources/document.docx" ) )
					.variables ( null )
					.build ( );

	DocumentDTO example2 = DocumentDTO.builder ( )
					.document ( FileUtils.loadFileFromResources ( "./templateResources/otherDocument.docx" ) )
					.variables ( null )
					.build ( );

	List < DocumentDTO > documentList = new ArrayList <> ( );
	output.add ( example1 );
	output.add ( example2 );
```

Then in the .docx output after replace our `${DOCUMENT_LIST}` all the content of `document.docx` and otherDocument.docx will be inserted in the variable.
Also this documents can have their variables, in tha case we only need to create a map with te content like in the previos example.
