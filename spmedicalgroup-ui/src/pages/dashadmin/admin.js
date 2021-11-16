import { Component } from "react";

export default class Admin extends Component {
    constructor(props){
        super(props);
        this.state = {
            seila : ''
        }
    }

     render(){
         return(
             <div>
                 <h1>Página do ADM que vai ter cadastro, exclusão e alteração de TUDO '-'</h1>
             </div>
         )
     }   

}