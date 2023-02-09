Scaffolding has generated all the files and added the required dependencies.

However the Application's Startup code may require additional changes for things to work end to end.
Add the following code to the Configure method in your Application's Startup class if not already done:

        app.UseEndpoints(endpoints =>
        {
          endpoints.MapControllerRoute(
            name : "areas",
            pattern : "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );
        });



        var stringList = new List<string>();
foreach (var item in Model.SliderText)
{
    stringList.Add(item);
}

var typedStrings = Json.Encode(stringList);

$("#typed").typed({
    strings: typedStrings,
    typeSpeed: 90, backDelay: 700, contentType: "html", loop: !0, resetCallback: function () { newTyped() }
}), $(".reset").click(function () { $("#typed").typed("reset") })
