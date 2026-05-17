using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using プロトタイプ.Scripts.Models;
namespace プロトタイプ.Scripts.Nodes.UI;

public partial class InventoryWindow : PanelContainer
{
    [Export] public VBoxContainer ItemContainer;

    public void RefreshList()
    {
        // 1. 古いリスト表示をクリア
        if (ItemContainer == null) return;
        
        foreach (Node child in ItemContainer.GetChildren())
        {
            child.QueueFree();
        }

        // 2. GameStateのインベントリ（Dictionary<int, int>）を取得
        var inventory = GameState.Instance.Inventory;

        if (inventory.Count == 0)
        {
            var emptyLabel = new Label();
            emptyLabel.Text = "なにももっていない...";
            ItemContainer.AddChild(emptyLabel);
            return;
        }

        // 3. 所持アイテムをループで回して表示
        foreach (var pair in inventory)
        {
            int itemId = pair.Key;
            int count = pair.Value;

            // Masterからアイテム情報を検索
            var itemData = ItemMaster.AllItems.FirstOrDefault(i => i.Id == itemId);
            if (itemData == null) continue;

            // アンディーメンテ風に「名前 x個数」のラベルを作成
            var label = new Label();
            label.Text = $"{itemData.Name} x{count}";
            
            // ヒント（Description）をツールチップに設定
            label.TooltipText = itemData.Description; 
            
            ItemContainer.AddChild(label);
        }
    }

    // 閉じるボタンなどを設置した場合はここで非表示にする
    public void OnCloseButtonPressed()
    {
        this.Visible = false;
    }
}