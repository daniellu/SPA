 <!-- src/components/Home.vue -->

  <template>
    <div>      
      <div class="row">
         <div class="form-group">
            <label for="queryArea">Query</label>            
            <textarea class="form-control" id="queryArea" v-model="queryString"></textarea>
          </div>  
      </div>
      <div>
        <div class="panel panel-default">
          <div class="panel-body">
            Basic panel example
          </div>
        </div>
      </div>
      <div class="row" id="graphDiv"></div>
    </div>
    
  </template>

  <script>
  export default {
    data() {
      return {
        queryString: 'This is the default quote value'
      }
    },
    methods: {
      getQuote() {
        this.$http
          .get('http://localhost:3001/api/random-quote', (data) => {
            this.queryString = data;
          })
          .error((err) => console.log(err))
      }
    }
  }
  </script>