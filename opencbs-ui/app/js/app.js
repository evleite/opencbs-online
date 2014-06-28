/**
 * Created by Oskar on 27/06/2014.
 */

// define the main App
(function(){
    var app = angular.module('opencbs-ui', []);
    app.controller('StoreController', function(){
        this.products = gems;
    });

    var gems = [{
        name: 'Dodecahedron',
        price: 2.95,
        description: '. . .',
        canPurchase: true,
        soldOut: true
    },
        {    name: 'Dodecahedron 2',
            price: 3.95,
            description: '. . . something interesting',
            canPurchase: true,
            soldOut: false
        }
    ];
})();

