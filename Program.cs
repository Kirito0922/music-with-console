using System.Collections;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

var helper = new PaginationHelper<char>(new List<char>{'a', 'b', 'c', 'd', 'e', 'f'}, 4);
int pages = helper.PageCount; // should == 2
int items = helper.ItemCount; // should == 6

helper.PageItemCount(0); // should == 4
helper.PageItemCount(1); // last page - should == 2
helper.PageItemCount(2); // should == -1 since the page is invalid

// pageIndex takes an item index and returns the page that it belongs on
helper.PageIndex(5); // should == 1 (zero based index)
helper.PageIndex(2); // should == 0
helper.PageIndex(20); // should == -1
helper.PageIndex(-10); // should == -1

public class PaginationHelper<T>
{
// TODO: Complete this class
  
/// <summary>
/// Constructor, takes in a list of items and the number of items that fit within a single page
/// </summary>
/// <param name="collection">A list of items</param>
/// <param name="itemsPerPage">The number of items that fit within a single page</param>
  
    private IList<T> collection;
    private int itemsPerPage;

    public PaginationHelper(IList<T> collection, int itemsPerPage)
    {
        this.collection = collection;
        this.itemsPerPage = itemsPerPage;
    }

/// <summary>
/// The number of items within the collection
/// </summary>
    public int ItemCount
    {
        get
        {
            return collection.Count;
        }
    }

/// <summary>
/// The number of pages
/// </summary>
    public int PageCount
    {
        get
        {
            if(ItemCount%itemsPerPage == 0)
                return ItemCount/itemsPerPage;
            else
                return ItemCount/itemsPerPage+1;
        }
    }

/// <summary>
/// Returns the number of items in the page at the given page index 
/// </summary>
/// <param name="pageIndex">The zero-based page index to get the number of items for</param>
/// <returns>The number of items on the specified page or -1 for pageIndex values that are out of range</returns>


    public int PageItemCount(int pageIndex)
    {
        //* Error
        /*if(pageIndex < PageCount-1 && pageIndex > -1)
            return itemsPerPage;
        else if(pageIndex == PageCount-1 && ItemCount%itemsPerPage == 0)
            return itemsPerPage;
        else if(pageIndex == PageCount-1 && ItemCount%itemsPerPage != 0)
            return ItemCount%itemsPerPage;
        else
            return -1;*/

        //* Solución
        /*if(pageIndex >= PageCount || pageIndex <= -1)
            return -1;
        else if(pageIndex == PageCount-1 && ItemCount%itemsPerPage == 0) // Si este if estuviera debajo del penúltimo, también sería redundante, pues ya filtré todos los valores y sólo quedaría el PageCount - 1, por lo que no habría que mencionarlo, simplemente se pondría la otra condición
            return itemsPerPage;
        else if(pageIndex == PageCount-1 && ItemCount%itemsPerPage != 0)
            return ItemCount%itemsPerPage;
        else if(pageIndex > -1 && pageIndex < PageCount-1) // Aquí es redundante que le diga ambas cosas, porque ya los valores que están fuera del rango ya fueron filtrados
            return itemsPerPage;
        else
            return -1;*/

        //* Solución mejorada
        if(pageIndex >= PageCount || pageIndex <= -1)
            return -1;
        else if(pageIndex == PageCount-1 && ItemCount%itemsPerPage == 0)
            return itemsPerPage;
        else if(pageIndex == PageCount-1 && ItemCount%itemsPerPage != 0)
            return ItemCount%itemsPerPage;
        else 
            return itemsPerPage;

        //* Otras soluciones (Usuarios: zabihy, TomaszCitko)
        /*if(pageIndex >= PageCount || pageIndex <= -1)
            return -1;
        else if(pageIndex < PageCount-1)
            return itemsPerPage;
        else if(ItemCount%itemsPerPage == 0)
            return itemsPerPage;
        else
            return ItemCount%itemsPerPage;*/
    }

/// <summary>
/// Returns the page index of the page containing the item at the given item index.
/// </summary>
/// <param name="itemIndex">The zero-based index of the item to get the pageIndex for</param>
/// <returns>The zero-based page index of the page containing the item at the given item index or -1 if the item index is out of range</returns>



    public int PageIndex(int itemIndex)
    {
        if(itemIndex < collection.Count && itemIndex > -1)
            return itemIndex/itemsPerPage;
        else
            return -1;
    }
}