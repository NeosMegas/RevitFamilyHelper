# RevitFamilyHelper
Various helper functions for working with Revit families.

Макрос RemoveAllTypes удаляет все типоразмеры из открытого в данный момент файла семейства (RFA) кроме типоразмера с именем "default". Либо, если "default" не найден, то все, кроме одного последнего.

Для работы макроса поместите папки AddIn и Source в %ProgramData%\Autodesk\Revit\Macros\ <версия Revit>\Revit\AppHookup\RevitFamilyHelper (например, C:\ProgramData\Autodesk\Revit\Macros\2019\Revit\AppHookup\RevitFamilyHelper) и перезапустите Revit, если он был открыт. После этого во вкладке "Управление", панель "Макросы", "Диспетчер макросов" во вкладке "Приложение" появится соответствующий модуль.
