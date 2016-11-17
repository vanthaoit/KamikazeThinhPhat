/// <reference path="/Assets/admin/libs/angular/angular.js" />
(function (app) {
    app.controller('productListController', productListController);

    productListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];

    function productListController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.products = [];

        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.getProducts = getProducts;
        $scope.keyword = '';
        $scope.search = search;

        $scope.selectAll = selectAll;
        $scope.deleteProduct = deleteProduct;

        function search() {
            getProducts();
        }

        $scope.isAll = false;
        function selectAll() {
            if ($scope.isAll == false) {
                angular.forEach($scope.products, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            }else
            {
                angular.forEach($scope.products, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }

        }



        $scope.$watch("products", function (newValue, oldValue) {
            var checked = $filter("filter")(newValue, { checked: true });
            if (checked.length) {
                $scope.selected = checked;
                $('#btnDelete').removeAttr('disabled');
            } else {
                $('#btnDelete').attr('disabled', 'disabled');
            }
        }, true);

        function deleteProduct(id, name) {
          
            $ngBootbox.confirm("Bạn có chắc muốn xóa sản phẩm " + name + "với ID = " + id + " ?").then(function () {
                
                var config = {
                    params: {
                        id:id
                    }
                }
                apiService.del("api/product/delete", config, function (result) {
                    notificationService.displaySuccess("Bạn đã xóa thành công " + result.data.Name + "!!!");
                    search();
                }, function () {
                    notificationService.displayWarning("Xóa không thành công !!!");
                });

            });
        }

        function getProducts(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 2
                }
            }
            apiService.get('/api/product/getall', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không có bản ghi nào được tìm thấy.');
                }
                $scope.products = result.data.Items;
                $scope.page = result.data.Page;
                $scope.totalPages = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Load product failed.');
            });
        }

        $scope.getProducts();
    }

  
})(angular.module('kamikazeThinhPhat.products'));