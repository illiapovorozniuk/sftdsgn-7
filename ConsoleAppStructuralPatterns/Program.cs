//using ClassLibraryStructuralPatterns.Composite1;
//using ClassLibraryStructuralPatterns.Composite2;
//using ClassLibraryStructuralPatterns.FlyWeight;
//using ClassLibraryStructuralPatterns.Proxy;
//using System.Net.Http.Headers;

//Console.WriteLine("First task:");
//List<string> classlist = new List<string>() { "first_class", "second_class" };
//List<string> classlistNull = new List<string>();
//LightElementNode h1 = new LightElementNode("h1", true, false, classlist);
//LightElementNode img = new LightElementNode("img", false, true, classlistNull);

//LightElementNode h2 = new LightElementNode("h2", true, false, classlistNull);
//LightElementNode table = new LightElementNode("table", true, false, classlistNull);


//h1.AppendChild(new LightTextNode("Hello world)"));
//h1.AppendChild(img);
////Заміна тегу img на h2
//h1.ReplaceChild(h2, img);
////Заміна тегу а на h2
//h1.InsertBefore(new LightElementNode("a", true, false, classlistNull), h2);
////Додавання у вже існуючий child node нового node елемента
//h2.AppendChild(table);
//LightNode someNewElement = h1.Clone();
//Console.WriteLine(h1.GetOuterHtml());



////Composite "MarvellArtefact"
//Console.WriteLine("\nSecond task:");
//MarvelHero ironMan = new MarvelHero("Iron man", 400);
//ironMan.SetLogging(true);


//ArtefactContainer glove = new ArtefactContainer("Glove of power");
//glove.AddArtefact(new Artefact("Mind gem", 5, 200));
//glove.AddArtefact(new Artefact("Power gem", 6, 200));
//glove.AddArtefact(new Artefact("Reality gem", 7, 150));
//glove.AddArtefact(new Artefact("Time gem", 8, 100));
//glove.AddArtefact(new Artefact("Soul gem", 9, 150));

//ironMan.AddArtifact(glove);

//Console.WriteLine(glove.GetPowerBuf());
//ironMan.Strike();



////Proxy
//Console.WriteLine("\nThird task:");
//ITextReader reader = new SmartTextReader();

//var res = reader.Read("file.txt");

//reader = new SmartTextChecker(reader);

//var res2 = reader.Read("file.txt");

//reader = new SmartTextReaderLocker(reader, "");



////LightWeight
//Console.WriteLine("\nFourth task:");
//TextWebLoader loader = new TextWebLoader("https://www.gutenberg.org/cache/epub/1513/pg1513.txt");
//string text = loader.GetText();

//LightParser parser = new LightParser();
//LightElementNode node = parser.GetLightHTML(text);
//Console.WriteLine(node.GetOuterHtml());

using ClassLibraryStructuralPatterns.Composite1;
using ClassLibraryStructuralPatterns.Lab_7;
using System.Runtime.CompilerServices;
//Observed(Спотстерігач)

Console.WriteLine("Observed(Спотстерігач)");
LightElementNode element = new LightElementNode("div", true, false, new List<string>());

element.GetOuterHtml();
element.AddEventListener("click", (e) =>
{
    LightElementNode elem = e as LightElementNode;
    Console.WriteLine($"You clicked on the {elem.TagName} tag");
});
element.AddEventListener("focuse", (e) =>
{
    LightElementNode elem = e as LightElementNode;
    Console.WriteLine($"You are focused on the {elem.TagName} tag");
});

Console.WriteLine(element.GetOuterHtml());
element.Event("click");
element.Event("focuse");

//Template 
Console.WriteLine("\nTEMPLATE:");
LightElementNode childElement = new LightElementNode("p", true, false, new List<string>() { "btn", "df" });
element.AppendChild(childElement);
element.RemoveChild(childElement);
Console.WriteLine(element.GetOuterHtml());

//Iterator
LightElementNode root = element;
var child1 = new LightElementNode("p", true, false, new List<string>() { "btn", "df" });
var child2 = new LightTextNode("Hello there");
Console.WriteLine("\nITERATOR:");
root.AppendChild(child1);
child1.AppendChild(child2);
Console.WriteLine("\nПеревірка у глибину");
foreach (LightNode node in new DepthFirstIterator(root))
{
    Console.WriteLine(node is LightElementNode ? $"Tag - {((LightElementNode)node).TagName}" : "Text");
}

child1.RemoveChild(child2);
root.AppendChild(child2);
Console.WriteLine("\nПеревірка у глибину");
foreach (LightNode node in new BreadthFirstIterator(root))
{
    Console.WriteLine(node is LightElementNode ? $"Tag - {((LightElementNode)node).TagName}" : "Text");
}

//Strategy
Console.WriteLine("\nStrategy:");
LightElementNode.Image image = new LightElementNode.Image("https://randomsite.com/image.jpg");
Console.WriteLine(image.GetOuterHtml());