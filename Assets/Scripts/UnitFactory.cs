﻿using UnityEngine;

public class UnitFactory
{
    private BookshelfController template;

    public UnitFactory(GameObject templateUnit)
    {
        template = templateUnit.GetComponent<BookshelfController>();
        if (template == null)
        {
            Debug.Log("UnitFactory: Could not find BookshelfController script on template");
        }
    }

    public IUnit BlankIUnit()
    {
        return new Bookshelf("", "", template.ShelfCount, template.ShelfWidth);
    }

    public IUnit StartIUnit(string start)
    {
        return new Bookshelf(start, "", template.ShelfCount, template.ShelfWidth);
    }
}