(function (app) {
    app.controller('productCategoryEditController', productCategoryEditController);

    productCategoryEditController.$inject = ['apiService','notificationService','$scope','$state','$ngBootbox','$filter','$stateParams'];

    function productCategoryEditController(apiService, notificationService, $scope, $state, $ngBootbox, $filter, $stateParams) {

        $scope.productCategory = {
            CreatedDate: new Date(),
            Status: true
        }
        
        $scope.UpdateProductCategory = UpdateProductCategory;

        function loadProductCategoryDetail() {
            apiService.get('api/productcategory/getbyid/'+ $stateParams.id, null,function (result) {
                $scope.productCategory = result.data;
            }, function (error) {
                notificationService.displayError('Cannot get getbyid of productCategory !!!');

            });
        }

        function UpdateProductCategory() {
            apiService.put('api/productcategory/update', $scope.productCategory, function (result) {
                notificationService.displaySuccess('Cập nhật thành công ' + result.data.Name + '!!!');
                $state.go('product_categories');
            }, function (error) {
                notificationService.displayError('Cập nhật thất bại !!!');
            });
        }
        loadProductCategoryDetail();
    }
})(angular.module('kamikazeThinhPhat.product_categories'));