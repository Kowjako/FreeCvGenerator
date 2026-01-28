### Free CV Generator
How to use?
1. Install .NET 10
2. Open solution
3. Put your photo inside logo folder (if name will be changed, adjust path inside **CVDocument.cs**)
4. In Program.cs write all needed information
5. Run program to preview result
   
If you are satisfied with the result, replace:
```c#
document.GeneratePdfAndShow();
```
with
```c#
document.GeneratePdf("MY_GIGA_CV.pdf");
```
Run progam, then go to this program folder -> CvGenerator\bin\Debug\net10.0 and grab your CV

### Sample result
<img width="577" height="820" alt="Screenshot_1" src="https://github.com/user-attachments/assets/ce6709e0-c87c-486a-b07d-0b8aaeb48896" />


Special thanks to QuestPDF, for amazing library https://www.questpdf.com/
