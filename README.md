# COMPONENT-DOCUMENTS-DOC - HOW TO USE

Welcome to this awesome component !!!

<br>

You will be able to generate and read your documents very easily.

<br>
<br>

## REPLACE ALL THE VARIBLES OF THE TEMPLATE

<br>

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
  also this one ${NUMBER}.

<br>
<br>

You will then need a DTO **Object** that contains all the document data to replace in the template.  
In this example we have the `ExampleTemplate.java` that extends of `GenerableDocument` and looks like this :

```java
		@Getter
		@Setter
		public class ExampleTemplate extends GenerableDocument
		{
			private String variableExample = "(I am a replaced variable) ";
			private Integer number = 69;
		}
```


> [!CAUTION]
> In the **Java Class** the varible name must be in camelCase as `variableExample` while in the .docx file
> should look like `${VARIABLE_EXAMPLE}`, otherwise it doesn't work.

<br>
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

Then we need the an output folder with an output empty file, in this case this will be the path with the empty file.

```java
	private String outputPath = "src/main/resources/templateResources/exampleDoc_output.docx";
```
<br>

Finally we call the writeFile method from Docx Document Service and pass in parameters the `templateFile`, `outputPath` and `exampleDto`.
This method will return an `Optional` of `File`.
```java
	Optional < File > output = service.writeFile ( templateFile, outputPath, exampleDto );
```
		

