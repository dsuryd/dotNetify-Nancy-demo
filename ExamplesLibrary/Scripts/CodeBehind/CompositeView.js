var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var LinkedTreeViewVM = (function (_super) {
    __extends(LinkedTreeViewVM, _super);
    function LinkedTreeViewVM() {
        _super.apply(this, arguments);
    }
    LinkedTreeViewVM.prototype.expand = function (iItem, iElement, iParentItem) {
        var vm = this;
        if (iItem.Children() == null) {
            // Send the item Id to expand to the server through ExpandId property binding.
            vm.ExpandId(iItem.Id());
            // When the new tree item in the ExpandedItem is received, use it to replace the one here.
            vm.$once(vm.ExpandedItem, function (iNewItem) {
                if (iItem.Id() == iNewItem.Id())
                    iParentItem.Children.replace(iItem, iNewItem);
                // The iNewItem object now belongs to the tree, and must be removed from ExpandedItem.
                vm.ExpandedItem(null);
            });
        }
        // Toggle the expanded state locally.
        vm.$preventBinding(function () { return iItem.Expanded(!iItem.Expanded()); });
    };
    return LinkedTreeViewVM;
})(TreeViewVM);
