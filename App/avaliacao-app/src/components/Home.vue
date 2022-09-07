<template>
    <div class="col-12" style="margin-bottom: 50px;">
        <h5 class="card-title">Avaliação LINX - Balanço</h5>
    </div>
    <div class="col-12 table-responsive">
        <table class="table  caption-top">
            <caption>Meu Balanço </caption>
            <thead class="table-dark">
                <tr>
                    <th scope="col">Tipo</th>
                    <th scope="col">Data</th>
                    <th scope="col">Descrição</th>
                    <th scope="col">Valor</th>

                </tr>
            </thead>
            <tbody>
                <tr v-for="balanco in this.balancos" v-bind:key="balanco.id">
                    <td v-bind:class="cssReceitaDespesa(balanco.tipo.descricao)">{{balanco.tipo.descricao}}</td>
                    <td>{{balanco.data}}</td>
                    <td>{{balanco.descricao}}</td>
                    <td>R$ {{formatarMoeda(balanco.valor)}}</td>

                </tr>
            </tbody>
            <tfoot class="table-secondary">
                <tr>
                    <td style="text-align: right !important;" class="text-right" colspan=3>Total</td>
                    <td v-bind:class="this.total > 0? 'receita': 'despesa'">R$ {{formatarMoeda(this.total)}}</td>
                </tr>
            </tfoot>
        </table>
    </div>
</template>

<script>
import axios from 'axios'
import dayjs from 'dayjs';
export default {
    name: 'HomeComponent',
    data() {
        return {
            balancos: [],
            total: 0
        }
    },
    methods: {
        carregarBalancos() {
            axios.get('http://localhost:41274/api/v1/Balanco')
                .then((res) => {
                    this.balancos = res.data?.items;
                    this.balancos.map(b => {
                        b.data = dayjs(b.data).format('DD/MM/YYYY');
                    })

                    this.calcularBalanco();

                })
                .catch((error) => {
                    console.error(error)
                })
        },
        cssReceitaDespesa(tipo) {
            
            if (tipo === 'Receita') {
                return 'receita'
            } else {
                return 'despesa'
            }
        },
        calcularBalanco() {
            var receitas = this.balancos.filter(b => b.tipo.descricao === 'Receita').reduce((total, obj) => obj.valor + total, 0)
            var despesas = this.balancos.filter(b => b.tipo.descricao === 'Despesa').reduce((total, obj) => obj.valor + total, 0)

            this.total = (receitas - despesas);


        },
        formatarMoeda(valor){
            return new Intl.NumberFormat('pt-BR', { maximumFractionDigits: 2, minimumFractionDigits: 2 }).format(valor);
        }

    },
    beforeMount() {
        this.carregarBalancos();
    }
}

</script>

<style>
.despesa {
    color: red;
}

.receita {
    color: blue;
}
</style>